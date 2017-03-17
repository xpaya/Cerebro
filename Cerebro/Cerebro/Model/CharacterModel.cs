namespace Cerebro.Model
{
    public class CharacterModel : BaseModel
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value; 
                OnPropertyChanged();
            }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value; 
                OnPropertyChanged();
            }
        }

    }
}