namespace AbstractFactoryMethod
{
    public class AbstractMethodDataItem
    {
        public object DataItem { get; private set; }

        public AbstractMethodDataItem(object dataItem)
        {
            DataItem = dataItem;
        }
    }
}