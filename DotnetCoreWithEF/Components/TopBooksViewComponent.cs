﻿using DotnetCoreWithEF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreWithEF.Components
{
    public class TopBooksViewComponent: ViewComponent
    {
        private readonly IBookRepository _repository;

        public TopBooksViewComponent(IBookRepository bookRepository)
        {
            _repository = bookRepository;            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books=_repository.GetTopBooks();
            return View(books);
        }
    }
}
