import { Component, Input } from "@angular/core";
import { Battle } from 'src/app/common/battle';
import { CharClass } from 'src/app/common/char-class';
import { BattleService } from 'src/app/common/services/battle.service';

@Component({
    selector: 'battle-list',
    templateUrl: './battle-list.component.html',
    styleUrls: ['./battle-list.component.css']
})
export class BattleListComponent {
    @Input() battleList: Battle[];
    battleService: BattleService = new BattleService();

    ngOnInit(){
        this.battleService.getBattles().subscribe(data => this.battleList = data);
      }
}