import { Weapon } from '../weapon'
import { StatObject } from '../stat-object'

const woodenStaff = new Weapon('Wooden Staff', 4, 0, 0, 'Staff', false, new StatObject(0, 0, 0, 0, 1, 0))
const woodenBow = new Weapon('Wooden Bow', 6, 0, 1, 'Bow', true, new StatObject(0, 0, 0, 0, 0, 0))
const combatStaff = new Weapon('Combat Staff', 6, 1, 1, 'Staff', false, new StatObject(0, 0, 0, 0, 0, 0))
const ironSword = new Weapon('Iron Sword', 8, 0, 1, 'Sword', false, new StatObject(0, 0, 0, 0 ,0, 0))
const ironAxe = new Weapon('Iron Axe', 8, 1, 0, 'Axe', false, new StatObject(0, 0, 0, 0, 0, 0,))
const ironDagger = new Weapon('Iron Dagger', 4, 0, 1, 'Dagger', false, new StatObject(0, 0, 0, 0, 0, 0))
const ironScythe = new Weapon('Iron Scythe', 6, 0, 1, 'Scythe', false, new StatObject(0, 0, 0, 0, 0, 0))
const leatherWhip = new Weapon('Leather Whip', 6, 0, 1, 'Whip', true, new StatObject(0, 0, 0, 0, 0, 0))

export class WeaponList {
    list: Weapon[] = [woodenStaff, combatStaff, ironSword, ironDagger, ironAxe, ironScythe, woodenBow, leatherWhip];
    getWeapon(name): Weapon {
        return this.list.filter(weapon => weapon.name == name)[0]
    }
}