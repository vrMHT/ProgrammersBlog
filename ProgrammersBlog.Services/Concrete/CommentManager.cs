﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Services.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var commentCount = await _unitOfWork.Comments.CountAsync();
            if (commentCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentCount);
            }

            return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hatayla karsilasildi.", -1);
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var commentCount = await _unitOfWork.Comments.CountAsync(c => !c.IsDeleted);
            if (commentCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentCount);
            }

            return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hatayla karsilasildi.", -1);
        }
    }
}