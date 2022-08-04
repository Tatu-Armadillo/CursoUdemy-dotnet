using System.Collections.Generic;

namespace UdemyCurso.Data.Converter.Contrat
{
    public interface IParse<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}