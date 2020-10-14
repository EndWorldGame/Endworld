import { Weapon } from '../weapon'
import { StatObject } from '../stat-object'
import { Armor } from '../armor'

const emptyStats = new StatObject(0, 0, 0, 0, 0, 0);

const commonRobe = new Armor('Common Robe', 'Cloth', 0, 1, emptyStats);
const leatherArmor = new Armor('Leather Armor', 'Light', 1, 0, emptyStats);
const ironScaleMail = new Armor('Iron Scale Mail', 'Medium', 2, 0, emptyStats);
const ironPlateMail = new Armor('Iron Plate Mail', 'Heavy', 3, 0, new StatObject(0, 0, 0, -1, 0, 0));

export class ArmorList {
    list: Armor[] = [commonRobe, leatherArmor, ironScaleMail, ironPlateMail];
    getArmor(name): Armor {
        return this.list.filter(armor => armor.name == name)[0]
    }
}