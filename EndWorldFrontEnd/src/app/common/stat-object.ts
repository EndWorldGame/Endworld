export class StatObject {
    health: number;
    abilityPoints: number;
    strength: number;
    agility: number;
    mind: number;
    spirit: number;

    constructor(health: number, abilityPoints: number, strength: number, agility: number, mind: number, spirit: number){
        this.health = health;
        this.abilityPoints = abilityPoints;
        this.strength = strength;
        this.agility = agility;
        this.mind = mind;
        this.spirit = spirit;
    }
}