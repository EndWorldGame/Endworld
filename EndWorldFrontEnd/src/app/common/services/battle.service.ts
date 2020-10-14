import { Injectable } from "@angular/core";
import { of, Observable } from 'rxjs';
import { BattleList } from '../assets/battle-list';
import { Battle } from '../battle';

@Injectable()
export class BattleService {
    battleList: BattleList = new BattleList();
    getBattles(): Observable<Battle[]> {
        return of(this.battleList.list);
    }
}