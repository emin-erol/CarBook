﻿using CarBook.Application.Features.Mediator.Results.ReservationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationDateQuery : IRequest<List<GetReservationDateQueryResult>>
    {
    }
}
