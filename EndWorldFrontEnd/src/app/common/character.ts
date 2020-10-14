import { CharClass } from './char-class';
import { Weapon } from './weapon';
import { Armor } from './armor';
import { StatObject } from './stat-object';
import { CharRace } from './char-race';

export class Character {
    constructor(name: string, charClass: CharClass, charRace: CharRace, weapon: Weapon, armor: Armor){
        this.name = name,
        this.charClass = charClass,
        this.charRace = charRace,
        this.weapon = weapon,
        this.armor = armor
        this.currentHealth = this.getMaxHealth();
        this.currentAbilityPoints = this.getMaxAbilityPoints();
    }
    name: string;
    charClass: CharClass;
    charRace: CharRace;
    weapon: Weapon;
    armor: Armor;
    bonusStats: StatObject = new StatObject(0, 0, 0, 0, 0, 0);
    level: number = 1;
    currentHealth: number;
    currentAbilityPoints: number;

    getCurrentHealth(){
        return this.currentHealth;
    }

    getCurrentAbilityPoints(){
        return this.currentAbilityPoints;
    }

    getMaxHealth(){
        return this.bonusStats.health + this.charRace.stats.health + this.charClass.stats.health
            + this.weapon.statMod.health + this.armor.statMod.health
    }

    getMaxAbilityPoints(){
        return this.bonusStats.abilityPoints + this.charRace.stats.abilityPoints + this.charClass.stats.abilityPoints
            + this.weapon.statMod.abilityPoints + this.armor.statMod.abilityPoints
    }

    getStrength(){
        return this.bonusStats.strength + this.charRace.stats.strength + this.charClass.stats.strength
            + this.weapon.statMod.strength + this.armor.statMod.strength
    }
    
    getAgility(){
        return this.bonusStats.agility + this.charRace.stats.agility + this.charClass.stats.agility
            + this.weapon.statMod.agility + this.armor.statMod.agility
    }

    getMind(){
        return this.bonusStats.mind + this.charRace.stats.mind + this.charClass.stats.mind
            + this.weapon.statMod.mind + this.armor.statMod.mind
    }

    getSpirit(){
        return this.bonusStats.spirit + this.charRace.stats.spirit + this.charClass.stats.spirit
            + this.weapon.statMod.spirit + this.armor.statMod.spirit
    }

    getClass(){
        return this.charClass
    }

    getRace(){
        return this.charRace
    }

    getArmor(){
        return this.armor
    }

    getWeapon(){
        return this.weapon
    }

    getLevel(){
        return this.level
    }
}