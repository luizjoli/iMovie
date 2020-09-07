using FluentValidation;

namespace iMovie.Domain.Service.Omdb
{
        public class ParameterSearchValidate : AbstractValidator<ParameterSearch>
    {
        private const int YEAR_FIRST_MOVIE = 1888;

        public static string SearchMsg => "A busca deve ser informado.";

        public static string YearMsg => $"Ano do filme deve ser maior que '{YEAR_FIRST_MOVIE}'.";

        public static string TypeMsg => "O tipo deve conter o valor 'movie','series' ou 'episode'.";

        public static string PlotMsg => "O plot deve conter o valor 'full' ou 'short'.";        

        public static string ReturnMsg => "O retorno deve conter o valor 'json' ou 'xml'.";

        public static string VersionMsg => "A versão deve ser maior que 1.";

        public static string PageMsg => "A página deve estar entre 1 e 100.";

        public ParameterSearchValidate()
        {
            RuleFor(s => s.Search).
            NotEmpty().
            NotNull().
            WithMessage(SearchMsg);
            
            
            RuleFor(p => p.Year).           
            GreaterThanOrEqualTo(YEAR_FIRST_MOVIE).           
            WithMessage(YearMsg);

            RuleFor(p => p.Type).        
            Matches("movie|series|episode").
            WithMessage(TypeMsg);


            RuleFor(p => p.Version).            
            NotEmpty().
            WithMessage(VersionMsg);


            RuleFor(p => p.Page).            
            GreaterThanOrEqualTo(1).
            LessThanOrEqualTo(100).
            WithMessage(PageMsg);

             RuleFor(p => p.Return).        
            Matches("json|xml").
            WithMessage(ReturnMsg);
            

        }
    }
}