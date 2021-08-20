This project is meant for simply testing and learn how Entityframework Core (EFC) behaviour in specific cases.

This is e.g. if an entity has a collection and the collection is updated to contain more, fewer, or new entities and the entity is then updated, what will happen with any entities that differ between the old and new collection.

The project is also meant to learn domain-driven design (DDD) and how it can be implemented together with EFC.

Regarding the behaviour and collection, if an old entity is not present in the new collection, and the foreign key is not allowed to be null, it will be deleted in the context.

Learned that Json will read all getters, so need to use JsonIgnore on getters that should not be sterialised. 

ModelBinder cannot bind to private setters in the DTOs when an endpoint is called. 


