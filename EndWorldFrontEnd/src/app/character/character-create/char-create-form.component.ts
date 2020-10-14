import { Component, ViewChild, Output, EventEmitter, Input } from '@angular/core';
import { CharClass } from '../../common/char-class';
import { NgForm } from '@angular/forms';
import { CharRace } from '../../common/char-race';

@Component({
    selector: 'char-create-form',
    templateUrl: './char-create-form.component.html',
    styleUrls: ['./char-create-form.component.css']
  })
  export class CharCreateFormComponent {
    @ViewChild('charCreateForm', {static: true, read: NgForm}) charCreateForm: NgForm;
    @Input() raceList: CharRace[];
    @Input() classList: CharClass[];
    @Output() formValue = new EventEmitter();
    formChangesSubscription;
    character = {};

    ngOnInit() {
      this.formChangesSubscription = this.charCreateForm.form.valueChanges.subscribe(x => {
        this.formValue.emit(x);
      })
    }

  }