import { StatObject } from './stat-object';
import { Weapon } from './weapon';
import { Armor } from './armor';

export class CharClass {
    name: string;
    stats: StatObject;
    defaultWeapon: Weapon;
    defaultArmor: Armor;
    classGroup: string;
    image: string;
    constructor(name: string, stats: StatObject, defaultWeapon: Weapon, defaultArmor: Armor, classGroup: string, 
        image: string = ""){
        this.name = name;
        this.stats = stats;
        this.defaultWeapon = defaultWeapon;
        this.defaultArmor = defaultArmor;
        this.classGroup = classGroup;
        this.image = image;
    }
}