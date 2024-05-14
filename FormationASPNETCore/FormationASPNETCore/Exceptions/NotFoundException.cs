namespace FormationASPNETCore.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string typeEntity, object key) : base($"Entité {typeEntity} introuvable avec la clé {key ?? "null"}") { }

    public NotFoundException(string message) : base(message) { }
}

public class NotFoundException<T> : NotFoundException
{
    public NotFoundException(object key) : base(typeof(T).Name, key) { }
}