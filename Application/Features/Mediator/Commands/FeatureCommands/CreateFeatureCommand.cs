﻿using MediatR;

namespace Application.Features.Mediator.Commands.FeatureCommands
{
    public class CreateFeatureCommand : IRequest
    {
        public string Name { get; set; }
        public CreateFeatureCommand(string name)
        {
            Name = name;
        }
    }
}
