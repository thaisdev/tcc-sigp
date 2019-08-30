namespace VirtusGo.Core.Domain.Core.Events
{
    public interface IHandler<in T>
    {
        void Handle(T message);
    }
}