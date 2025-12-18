using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Correct { get; set; } //Saber si se hizo bien o saber si se hizo mal
        public string ErrorMessage { get; set; } //mensaje de error
        public List<object> Objects { get; set; } //Para el GetAll

        public object Object { get; set; } //GetById => obtiene uno
    }
}
