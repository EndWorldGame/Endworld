import { CharClass } from '../char-class';
import { StatObject } from '../stat-object';
import { WeaponList } from './weapon-list';
import { ArmorList } from './armor-list';

const weaponList = new WeaponList();
const armorList = new ArmorList();

//Warriors
const guard = new CharClass('Guard', new StatObject(16, 4, 2, 0, 0, 0), 
    weaponList.getWeapon('Iron Sword'), armorList.getArmor('Leather Armor'), 'Warrior');
const gladiator = new CharClass('Gladiator', new StatObject(14, 6, 2, 0, 0, 0), 
    weaponList.getWeapon('Iron Dagger'), armorList.getArmor('Leather Armor'), 'Warrior');
const soldier = new CharClass('Soldier', new StatObject(14, 6, 1, 1, 0, 0), 
    weaponList.getWeapon('Iron Dagger'), armorList.getArmor('Leather Armor'), 'Warrior', 
    "../../../assets/Char/Human/soldier_default.png");

//Magicians
const psychic = new CharClass('Psychic', new StatObject(10, 10, 0, 0, 2, 0), 
    weaponList.getWeapon('Iron Scythe'), armorList.getArmor('Leather Armor'), 'Magician')
const sorceror = new CharClass('Sorceror', new StatObject(8, 12, 0, 0, 2, 0), 
    weaponList.getWeapon('Iron Scythe'), armorList.getArmor('Leather Armor'), 'Magician',
    "../../../assets/Char/Human/sorceror_default.png")
const druid = new CharClass('Druid', new StatObject(12, 8, 0, 0, 2, 0), 
    weaponList.getWeapon('Iron Scythe'), armorList.getArmor('Leather Armor'), 'Magician')

//Clerics
const skald = new CharClass('Skald', new StatObject(14, 6, 1, 0, 0, 1),
    weaponList.getWeapon('Iron Axe'), armorList.getArmor('Leather Armor'), 'Cleric')
const monk = new CharClass('Monk', new StatObject(12, 8, 0, 0, 0, 2),
    weaponList.getWeapon('Wooden Staff'), armorList.getArmor('Leather Armor'), 'Cleric') 
const mystic = new CharClass('Mystic', new StatObject(8, 12, 0, 0, 0, 2),
    weaponList.getWeapon('Wooden Staff'), armorList.getArmor('Leather Armor'), 'Cleric')

//Specialist
const hunter = new CharClass('Hunter', new StatObject(14, 6, 0, 2, 0, 0),
    weaponList.getWeapon('Leather Whip'), armorList.getArmor('Leather Armor'), 'Specialist')
const rogue = new CharClass('Rogue', new StatObject(14, 6, 0, 2, 0, 0,),
    weaponList.getWeapon('Iron Dagger'), armorList.getArmor('Leather Armor'), 'Specialist',
    "../../../assets/Char/Human/rogue_default.png")
const tamer = new CharClass('Tamer', new StatObject(14, 6, 0, 2, 0, 0),
    weaponList.getWeapon('Leather Whip'), armorList.getArmor('Leather Armor'), 'Specialist')

export class CharClassList{
    list: CharClass[] = [
        soldier,
        sorceror,
        rogue
    ]
}