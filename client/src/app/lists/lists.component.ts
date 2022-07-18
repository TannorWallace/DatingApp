import { Component, OnInit } from '@angular/core';
import { Member } from '../_models/member';
import { MemebersService } from '../_services/members.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  members: Partial<Member[]>;
  predicate = 'liked'
  constructor(private memberService: MemebersService) { }

  ngOnInit(): void {
    this.loadLikes();
  }
  loadLikes() {
    this.memberService.getlikes(this.predicate).subscribe(response => {
      this.members = response;
    })
  }
}
