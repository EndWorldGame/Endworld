import { StatObject } from './stat-object';

export class Weapon {
    name: string;
    damage: number;
    bonus: number;
    hit: number;
    type: string;
    ranged: boolean;
    statMod: StatObject;
    constructor(name: string, damage: number, bonus: number, hit: number, 
        type: string, ranged: boolean, statMod: StatObject){
            this.name = name;
            this.damage = damage;
            this.bonus = bonus;
            this.hit = hit;
            this.type = type;
            this.ranged = ranged;
            this.statMod = statMod;
    }
}