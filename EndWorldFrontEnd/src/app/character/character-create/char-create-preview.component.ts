import { Component, Input } from '@angular/core';
import { Character } from '../../common/character';

@Component({
    selector: 'char-create-preview',
    templateUrl: './char-create-preview.component.html',
    styleUrls: ['./char-create-preview.component.css']
  })
  export class CharCreatePreviewComponent {
   @Input() character: Character;

  }