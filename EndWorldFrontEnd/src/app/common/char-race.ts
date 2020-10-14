import { StatObject } from './stat-object'

export class CharRace {
    constructor(name: string, stats: StatObject){
        this.name = name,
        this.stats = stats
    }
    name: string;
    stats: StatObject;
}