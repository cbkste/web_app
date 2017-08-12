using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.ContentfulFactories
{
    public interface IContentfulFactory<in T, out TO>
    {
        TO ToModel(T entry);
    }
}
