import { Component, Input } from "@angular/core";
import { Battle } from 'src/app/common/battle';

@Component({
    selector: 'battle-list-option',
    templateUrl: './battle-list-option.component.html',
    styleUrls: ['./battle-list-option.component.css']
})
export class BattleListOptionComponent {
    @Input() battle: Battle;

}