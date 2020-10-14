import { StatObject } from './stat-object';

export class Armor {
    name: string;
    weight: string;
    physicalResistance: number;
    magicResistance: number;
    statMod: StatObject;
    constructor(name: string, weight: string, physicalResistance: number, magicResistance: number, statMod: StatObject){
        this.name = name;
        this.weight = weight;
        this.physicalResistance = physicalResistance;
        this.magicResistance = magicResistance;
        this.statMod = statMod;
    }
}