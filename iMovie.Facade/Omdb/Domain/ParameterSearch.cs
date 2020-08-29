using FluentValidation.Results;

namespace iMovie.Facade.Omdb.Domain
{
    public class ParameterSearch
    {
        public ParameterSearch(string search)
        {
            Search = search;
        }

        public ParameterSearch(string search, string type, int? year, string returnType, int? page, int? version)
        {
            Search = search;
            Type = string.IsNullOrEmpty(type) ? Type : type;            
            Return = string.IsNullOrEmpty(returnType) ? Return : returnType;
            Version = version;
            Year = year;

        }

        public string Search { get; private set; }

        public string Type { get; private set; }

        public int? Year { get; private set; }

        public string Return { get; private set; } = "json";

        public int? Page { get; private set; } = 1;

        public int? Version { get; private set; } = 1;

        public ValidationResult IsOk()
        {
            return new ParameterSearchValidate().Validate(this);
        }

    }
}
