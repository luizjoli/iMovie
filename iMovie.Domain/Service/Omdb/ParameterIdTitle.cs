using FluentValidation.Results;

namespace iMovie.Domain.Service.Omdb
{
    public class ParameterIdTitle
    {
        public ParameterIdTitle(string imdbId, string title){
            Id = imdbId;
            Title = title;
        }

        public ParameterIdTitle(string imdbId, string title, string type, int? year,string plot, string returnType, string version){
            Id = imdbId;
            Title = title;
            Type =  string.IsNullOrEmpty(type) ? Type : type;            
            Plot =  string.IsNullOrEmpty(plot) ? Plot : plot;
            Return =  string.IsNullOrEmpty(returnType) ? Return : returnType;
            Version =  version;
            Year =  year;
        }

        public string Id { get; private set; }
        public string Title { get; private set; }

        public string Type { get; private set; }

        public int? Year { get; private set; }

        public string Plot { get; private set; } = "short";

        public string Return { get; private set; } = "json";

        public string Version { get; private set; } = "1";

        public ValidationResult IsOk()
        {
            return new ParameterIdTitleValidate().Validate(this);
        }

    }
}
