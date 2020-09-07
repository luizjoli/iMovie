using FluentValidation;

namespace iMovie.Domain.Service.Omdb
{
    public class ParameterIdTitleValidate : AbstractValidator<ParameterIdTitle>
    {
        private const int YEAR_FIRST_MOVIE = 1888;

        public static string ID_OR_TITLE_MESSAGE => "Id ou Título do Filme deve ser informado.";

        public static string YEAR_MESSAGE => $"Ano do filme deve ser maior que '{YEAR_FIRST_MOVIE}'.";

        public static string TYPE_MESSAGE => "O tipo deve conter o valor 'movie','series' ou 'episode'.";

        public static string PLOT_MESSAGE => "O plot deve conter o valor 'full' ou 'short'.";        

        public static string RETURN_MESSAGE => "O retorno deve conter o valor 'json' ou 'xml'.";

        public static string VERSION_MESSAGE => "A versão deve ser maior que 1.";

        public ParameterIdTitleValidate()
        {
            RuleFor(p => string.IsNullOrEmpty(p.Id) && string.IsNullOrEmpty(p.Title)).
            Equal(false).
            WithMessage(ID_OR_TITLE_MESSAGE);
            
            
            RuleFor(p => p.Year).           
            GreaterThanOrEqualTo(YEAR_FIRST_MOVIE).           
            WithMessage(YEAR_MESSAGE);

            RuleFor(p => p.Type).        
            Matches("movie|series|episode").
            WithMessage(TYPE_MESSAGE);

            RuleFor(p => p.Plot).            
            Matches("short|full").
            WithMessage(PLOT_MESSAGE);

            RuleFor(p => p.Version).            
            NotEmpty().
            WithMessage(VERSION_MESSAGE);

            RuleFor(p => p.Return).        
            Matches("json|xml").
            WithMessage(RETURN_MESSAGE);

        }
    }
}
