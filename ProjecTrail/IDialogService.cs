using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecTrail
{
    public interface IDialogService
    {
        Task<bool> ShowConfirmDialog(string title, string message, string accept, string cancel);
    }
}
