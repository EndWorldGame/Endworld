import { Weapon } from '../weapon'
import { StatObject } from '../stat-object'
import { Armor } from '../armor'
import { Battle } from '../battle';

const forestBattle = new Battle("Forest Battle");

export class BattleList {
    list: Battle[] = [forestBattle];
}