using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services.Contracts
{
    interface ICommentService
    {
        int AddComment(string content, int bookId, string userId);
    }
}
