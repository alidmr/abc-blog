﻿using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Aggregates.Users;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Shared.Exceptions;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserCommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error6), ApplicationErrorCode.Error6);

            if (user.IsDeleted)
                throw new BusinessException(nameof(ApplicationErrorCode.Error9), ApplicationErrorCode.Error9);

            user.Update(request.FirstName, request.LastName);

            await _userRepository.UpdateAsync(user);

            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateUserCommandResult()
            {
                Result = result > 0,
                Message = "İşlem başarılı"
            };
        }
    }
}
