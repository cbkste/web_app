using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.ILolEsportsFactory
{
    public interface ILolEsportsFactory<in T, out TO>
    {
        TO ToModel(T entry);
    }
}
