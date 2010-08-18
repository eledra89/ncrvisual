﻿using System.Collections.Generic;

namespace NCRVisual.RelationDiagram
{
    public interface IEntity
    {
        //Name of the entity
        string Name { get; set; }

        //Set of connected entities with this entity
        List<IEntity> Connections { get; set; }
    }
}
