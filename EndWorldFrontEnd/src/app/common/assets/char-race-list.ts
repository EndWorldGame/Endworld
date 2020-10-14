import { CharRace } from '../char-race'
import { StatObject } from '../stat-object'

const human = new CharRace('Human', new StatObject(2, 0, 0, 0, 1, 0))
const satyr = new CharRace('Satyr', new StatObject(2, 0, 0, 1, 0, 0))
const lizardman = new CharRace('Lizardman', new StatObject(4, -2, 1, 0, 0, 0))
const vampire = new CharRace('Vampire', new StatObject(2, 0, -1, 1, 0, -1))
const lightElf = new CharRace('Light Elf', new StatObject(0, 2, 0, 0, 0, 1))
const darkElf = new CharRace('Dark Elf', new StatObject(0, 2, 0, 0, 0, -1))

export class CharRaceList{
    list: CharRace[] = [
        human
    ]
    getRace(name): CharRace {
        return this.list.filter(charRace => charRace.name == name)[0]
    }
}