
namespace Solution
{

    public class OOPFireStormItem : Identity
    {
        public override bool Hit()
        {
            mapGenerator.player.inventory.AddItem("FireStorm",1);
            mapGenerator.mapdata[positionX, positionY] = null;
            Destroy(gameObject);
            return true;
        }
    }

}