using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Cerebro.ViewModel.Base;
using Windows.UI.Core;
using Cerebro.Common;
using Cerebro.Model;
using Cerebro.Views;
using CerebroInfo.Manager.Dto;

namespace Cerebro.ViewModel
{
    public class InfoListViewModel : BaseViewModel
    {
        public InfoListViewModel(Frame navigation) : base(navigation)
        {
        }

        public override void Navigate()
        {
            Navigate(typeof (InfoListView),this);
            SystemNavigationManager.GetForCurrentView().BackRequested += NavigationServiceBackRequested;
              

            LoadData();
           
        }
        private void NavigationServiceBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (_navigate.CanGoBack)
            {
                _navigate.GoBack();
            }
        }

        private ObservableCollection<CharacterModel> _characters;

        public ObservableCollection<CharacterModel> Character
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged();
            }
        }

        private ICommand _moreCommand;

        public ICommand MoreCommand
        {
            get
            {
                return _moreCommand ?? new CommandHandler(MoreData);
            }
        }

        private ICommand _startFor;

        public ICommand StartWithCommand
        {
            get
            {
                return _startFor ?? new CommandHandler(SearchStart);
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private async void SearchStart()
        {
            CharacterInfoDto info;
            if (string.IsNullOrEmpty(Name))
            {
                info = await CerebroInfo.Manager.MarvelManager.GetCharacters(25, 1);
            }
            else
            {
                info = await CerebroInfo.Manager.MarvelManager.SearchStartWith(Name, 25, 1);
            }
            
            _data = info.Characters.Select(characterDto => new CharacterModel()
            {
                Id = characterDto.Id,
                Description = characterDto.Description,
                Image = characterDto.Image,
                Name = characterDto.Name
            }).ToList();
            Character = new ObservableCollection<CharacterModel>(_data);
            lastIndex = _data.Count();
        }

        private List<CharacterModel> _data;
        private int lastIndex = 0;
        private async void MoreData()
        {
            CharacterInfoDto info;
            if (string.IsNullOrEmpty(Name))
            {
                info = await CerebroInfo.Manager.MarvelManager.GetCharacters(25, lastIndex);
            }
            else
            {
                info = await CerebroInfo.Manager.MarvelManager.SearchStartWith(Name,25, lastIndex);
            }
               
            _data.AddRange(info.Characters.Select(characterDto => new CharacterModel()
            {
                Id = characterDto.Id,
                Description = characterDto.Description,
                Image = characterDto.Image,
                Name = characterDto.Name
            }).ToList());

            Character = new ObservableCollection<CharacterModel>(_data);
            lastIndex = _data.Count();
        }

   
        public async void LoadData()
        {
            var info = await CerebroInfo.Manager.MarvelManager.GetCharacters(25, 1);
            _data = info.Characters.Select(characterDto => new CharacterModel()
            {
                Id = characterDto.Id, Description = characterDto.Description, Image = characterDto.Image, Name = characterDto.Name
            }).ToList();
            Character = new ObservableCollection<CharacterModel>(_data);
            lastIndex = _data.Count();
        }
    }
}