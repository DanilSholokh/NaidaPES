
public class PlayerCreatureData
{

    private int power;

    public int Power { get => power; private set => power = value; }



    public int addPowerCreature(int power)
        { return this.power += power; }

    public int removePowerCreature(int power)
    {
        if (this.power < power)
        {
            return 0;
        }

        return this.power -= power;
    }



    public void refreshToZeroPowerCreature()
        { power = 0; }



}
