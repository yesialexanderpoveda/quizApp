using System.Text.Json;


public class SessionHelper<T> where T : new()
{
    private readonly ISession _session;
    private readonly string _key;

    public SessionHelper(IHttpContextAccessor httpContextAccessor, string key)
    {
        _session = httpContextAccessor.HttpContext.Session;
        _key = key;
    }

    public T GetInstance()
    {
        var sessionData = _session.GetString(_key); // Se usa _session en lugar de IHttpContextAccessor.HttpContext.Session
        if (!string.IsNullOrEmpty(sessionData))
        {
            return JsonSerializer.Deserialize<T>(sessionData);
        }
        return new T(); // Usamos 'new T()' en lugar de Activator.CreateInstance<T>() para mayor claridad
    }

    public void SaveInstance(T instance)
    {
        var serializedData = JsonSerializer.Serialize(instance);
        _session.SetString(_key, serializedData); // Se usa _session en lugar de IHttpContextAccessor.HttpContext.Session
    }
}
