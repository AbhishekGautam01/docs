namespace data_structure.LFU_Cache
{
    public interface ICache
    {
        int Get(int key);
        void Add(int key, int value);
    }
}
