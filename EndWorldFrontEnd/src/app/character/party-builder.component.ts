import { Component, ViewChild, ElementRef } from '@angular/core';
import { CharClassList } from '../common/assets/char-class-list';
import { CharClass } from '../common/char-class';
import { CharRaceList } from '../common/assets/char-race-list';
import { CharCreateFormComponent } from './character-create/char-create-form.component';
import { NgForm } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';
import { Character } from '../common/character'
import { CharClassService } from '../common/services/char-class.service';
import { CharRace } from '../common/char-race';
import { CharRaceService } from '../common/services/char-race.service';
import { PartyService } from '../common/services/party.service';

@Component({
    selector: 'party-builder',
    templateUrl: './party-builder.component.html',
    styleUrls: ['./party-builder.component.css']
  })
  export class PartyBuilderComponent {
    character: Character;
    charClasses: CharClass[] = [];
    charRaces: CharRace[] = [];

    constructor(private charClassService: CharClassService, private charRaceService: CharRaceService,
        private partyService: PartyService){

    }

    ngOnInit(){
      this.charClassService.getCharClasses().subscribe(data => this.charClasses = data);
      this.charRaceService.getCharRaces().subscribe(data => this.charRaces = data);
    }

    updateCharacterPreview(formModel){
      if(formModel.charClass && formModel.charRace){
        this.character = this.generateChar(formModel);
      }
    }

    generateChar(formModel){
      let charClass: CharClass;
      let charRace: CharRace;
      this.charClassService.getCharClassByName(formModel.charClass).subscribe(data => charClass = data);
      this.charRaceService.getCharRaceByName(formModel.charRace).subscribe(data => charRace = data);
      return new Character(
          formModel.charName || '',
          charClass,
          charRace,
          charClass.defaultWeapon,
          charClass.defaultArmor
        )
    }

    validCharacter(): boolean {
      return (!!this.character && this.character.name.length > 0)
    }

    createCharacter(){
      confirm('are you sure?')
    }

  }