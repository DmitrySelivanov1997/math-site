﻿using MathSite.Domain.Logic.Groups;
using MathSite.Domain.Logic.Persons;
using MathSite.Domain.Logic.Users;

namespace MathSite.Domain.Common
{
	public interface IBusinessLogicManger
	{
		IGroupsLogic GroupsLogic { get; }
		IPersonsLogic PersonsLogic { get; }
		IUsersLogic UsersLogic { get; }
	}
}