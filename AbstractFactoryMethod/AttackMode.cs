namespace AbstractFactoryMethod
{
    public class AttackMode : AbstractMethod<AttackType>
    {
        public override AbstractMethodDataItem GetData(AttackType type)
        {
            AbstractMethodDataItem item = null;

            switch (type)
            {
                case AttackType.NormalAttack:
                    item = new AbstractMethodDataItem(new NormalAttack());
                    break;

                case AttackType.VerticalSlashAttack:
                    item = new AbstractMethodDataItem(new VerticalSlashAttack());
                    break;

                case AttackType.HorizontalSlashAttack:
                    item = new AbstractMethodDataItem(new HorizontalSlashAttack());
                    break;
            }

            return item;
        }
    }
}