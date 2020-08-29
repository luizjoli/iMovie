using FluentValidation;

namespace iMovie.Facade.Omdb.Domain
{
    public class ParameterIdTitleValidate : AbstractValidator<ParameterIdTitle>
    {
        private const int YEAR_FIRST_MOVIE = 1888;

        public static string IdorTitleMsg => "Id ou Título do Filme deve ser informado.";

        public static string YearMsg => $"Ano do filme deve ser maior que '{YEAR_FIRST_MOVIE}'.";

        public static string TypeMsg => "O tipo deve conter o valor 'movie','series' ou 'episode'.";

        public static string PlotMsg => "O plot deve conter o valor 'full' ou 'short'.";        

        public static string ReturnMsg => "O retorno deve conter o valor 'json' ou 'xml'.";

        public static string VersionMsg => "A versão deve ser maior que 1.";

        public ParameterIdTitleValidate()
        {
            RuleFor(p => string.IsNullOrEmpty(p.Id) && string.IsNullOrEmpty(p.Title)).
            Equal(false).
            WithMessage(IdorTitleMsg);
            
            
            RuleFor(p => p.Year).           
            GreaterThanOrEqualTo(YEAR_FIRST_MOVIE).           
            WithMessage(YearMsg);

            RuleFor(p => p.Type).        
            Matches("movie|series|episode").
            WithMessage(TypeMsg);

            RuleFor(p => p.Plot).            
            Matches("short|full").
            WithMessage(PlotMsg);

            RuleFor(p => p.Version).            
            GreaterThanOrEqualTo(1).
            WithMessage(VersionMsg);

            RuleFor(p => p.Return).        
            Matches("json|xml").
            WithMessage(ReturnMsg);

        }
    }
}
