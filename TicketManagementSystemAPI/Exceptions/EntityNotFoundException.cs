﻿namespace TicketManagementSystemAPI.Exceptions
{
    public class EntityNotFoundException:Exception
    {

          public EntityNotFoundException(long id) { }
          public EntityNotFoundException(string merrorMessage) : base(merrorMessage) { }

          public EntityNotFoundException(string merrorMessage,Exception innerException):base(merrorMessage, innerException) { }


        public EntityNotFoundException(int entityId, string entityName) : base(FormattableString.Invariant($"'{entityName}'with id '{entityId}' was not found")) { }

    }
}
