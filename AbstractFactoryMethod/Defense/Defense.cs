namespace AbstractFactoryMethod
{
    internal class Defense : IDefense
    {
        private readonly DefenseType defenseType;

        public Defense(DefenseType defenseType)
        {
            this.defenseType = defenseType;
        }

        public bool GetDefense(DefenseType defenseType)
        {
            if (this.defenseType == defenseType)
            {
                return true;
            }

            return false;
        }
    }
}