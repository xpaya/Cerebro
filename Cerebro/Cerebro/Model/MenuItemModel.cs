namespace Cerebro.Model
{
    public class MenuItemModel : BaseModel
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                OnPropertyChanged();
            }
        }

        private string _icon;

        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value; 
                OnPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value; 
                OnPropertyChanged();
            }
        }

    }
}