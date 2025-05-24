using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toast.Services
{
    public interface IToastService
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
