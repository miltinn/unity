public interface IDamageable<T> //T define o tipo da propriedade a ser recebida
{
    void Damage(T f);
}

public interface IKillable
{
    void Kill();
}