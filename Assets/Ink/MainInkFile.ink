CONST WATER = 0
CONST EARTH = 1
CONST FIRE = 2
CONST AIR = 3

EXTERNAL GetName(p)
EXTERNAL GetSurname(p)
EXTERNAL GetLike(p)
EXTERNAL GetDislike(p)
EXTERNAL GetProficiency(p)
EXTERNAL GetItem(p)

= Leaving_camp

{GetName(0)}: I think it's time for me to say goodbye to you all.
<color=red>Juan</color>: Are you sure of this?
{GetName(0)}: Sadly, I don't feel at home being here. 
{GetName(0)}: Nothing personal, but I feel the need to look for somewhere where I can feel at home.
<color=red>Juan</color>: I'm sorry to hear that, {GetName(0)}.
<color=blue>Thiago</color>: I hope you look what you're looking for..
{GetName(0)}: If we happen to meet again, I hope to be able to receive you guys with the same hospitality you showed me.
<color=red>Juan</color>: Farewell!
<color=blue>Thiago</color>: Farewell!
...
<color=red>Juan</color>: God damn it, they were the most hardworking of all of us.

->Reaching_new_camp

->DONE

= Reaching_new_camp

<A couple days of travel later>
{GetName(0)}: Hello? Is anyone there?
<Deafening silence>
{GetName(0)}: I think I'm all alone here. Bummer.
<Judging silence>
{GetName(0)}: Hope I'll find some comapny soon.

->DONE

= Alone_by_bonfire

{GetName(0)}: Hello, darkness, my old friend.
<Heartwarming silence>
{GetName(0)}: Hope you don't mind me disturbing you a little bit with a campfire. I need to get warm by the night.
<understandable silence>
{GetName(0)}: Well, that was another day. 
{GetName(0)}: Let us see what tomorrow brings me. Nighty night, darkness.

->DONE

= Day_two

{GetName(1)}: Hello? Ahoy? Anyone there?
{GetName(0)}: Hold it! Who's there?
{GetName(1)}: Finally, some company!
{GetName(0)}: Yes! ...And who are you?
{GetName(1)}: {GetName(1)} {GetSurname(1)}. And how should I call you?
{GetName(0)}: {GetName(0)} {GetSurname(0)}. Do you need a place to stay?
{GetName(1)}: I'd love to.
{GetName(0)}: Got an empty nice space near my tent. If you wish to, make yourself confortable over there.
{GetName(1)}: Many thanks, {GetName(0)}!
{GetName(0)}: You're welcome, {GetName(1)}.

->DONE

= Day_three

{GetName(0)}: So, {GetName(1)}, how was your day?
{GetName(1)}: Actually, it was pretty smooth. Way smoothier than my days with the last group I tagged with
{GetName(0)}: So you had company of another group, then?
{GetName(1)}: Yeah, but life there was boring. It didn't feel like *home*, you know? 
{GetName(1)}: I felt detached and alone, so I parted ways and here I am.
{GetName(0)}: Curious. Glad to see that I wasn't the only one.
{GetName(1)}: So you don't want only to survive, but to live in a home truly yours as well. Nice.
{GetName(0)}: I believe we can make a home together. Not just any camp, but a true home where we could feel cozy and confortable.

->DONE

= Day_four

{GetName(2)}: Look, {GetName(3)}, a lit bonfire!
{GetName(3)}: And look, {GetName(2)}, people around it!
{GetName(0)}: Yeah, but stay chill. We don't bite!
{GetName(1)}: Yeah, gather around and make yourselves at home.
{GetName(2)}: Thank you, you...
{GetName(0)}: {GetName(0)}.
{GetName(1)}: {GetName(1)}. 
{GetName(3)}: Well, we are {GetName(3)} and {GetName(2)}. 
{GetName(2)}: Are you guys around for a while?
{GetName(0)}: It's been a while now. But don't worry, there is space for you to get comfy.
{GetName(3)}: Oh well, thank you very much!

->DONE

= Day_five

{GetName(1)}: So, where are you guys from anyway?
{GetName(3)}: We actually got out from the same camp.
{GetName(0)}: Why have you guys left? Were you having trouble?
{GetName(2)}: We got out for a very lame reason, actually, it doesn't even deserve mentioning.
{GetName(3)}: The camp was functional, but being there was... How do I put it?
{GetName(0)}: Soulcrushing?
{GetName(1)}: Made you feel unwanted, meaningless and not at home?
{GetName(2)}: ...Exactly!
{GetName(3)}: So we left after somewhere we could feel at home.
{GetName(0)}: Oh boy, that's why we left our own groups and moved here!
{GetName(2)}: Holy moly we weren't the only ones.
{GetName(1)}: It's way more common that you'd imagine. There is no shame into looking for somewhere else you can feel good with yourself and the place you live in.
{GetName(0)}: Once again, welcome to the group.
{GetName(3)}: Thank you!

->DONE

= BarkNeedCamp
I should start by setting up a tent.
->DONE

= BarkNeedFood
Today I have to go find some food before anything else.
->DONE

= LikeWater0
{GetName(0)}: Before this all started, I used to live by the beach. 
{GetName(0)}: Went to sleep every night with the sound of crashing waves.
{GetName(1)}: I bet it sounded wonderful.
{GetName(0)}: It did indeed
->DONE
= LikeWater1
{GetName(0)}: Can you feel it get a bit colder?
{GetName(1)}: As a matter of fact, yes. Is that a bad thing?
{GetName(0)}: Not at all, I love it. My favourite season is the winter.
{GetName(1)}: Oh, great, then.
->DONE
= LikeWater2
{GetName(0)}: I hope it rains tomorrow.
{GetName(1)}: ...What?
{GetName(0)}: I hope it rains tomorrow. The toads croak and the noise helps me to sleep.
{GetName(1)}: In the middle of the wild?
{GetName(0)}: The toads croak louder, it's great
->DONE
= DislikeWater0
{GetName(0)}: Have you ever dreamed about drowning?
{GetName(1)}: Can't recall, I usually can't remember my dreams. Why is that?
{GetName(0)}: I had this nightmare last night. It was terrible. 
{GetName(0)}: I do hope never need to swim, for it wouldn't be much different from that nightmare.
->DONE
= DislikeWater1
{GetName(0)}:  May I ask you something?
{GetName(1)}:  Yeah, sure, what is it?
{GetName(0)}:  If and when you set out to gather food, please don't bring fish.
{GetName(1)}:  ...That's an odd request.
{GetName(0)}:  Seriously, it smells awful. And the stench gets everywere. Please don't bring them.
->DONE
= DislikeWater2
{GetName(0)}: The end of society gave us a rather unexpected good thing.
{GetName(1)}: Besides not having to worry about jobs, stocks and taxes?
{GetName(0)}: No more alcohol.
{GetName(1)}: Beg your pardon?
{GetName(0)}: No more alcohol. No more drunk people. No more that ethylic foul smell. Just wonderful. 
->DONE

= LikeEarth0
{GetName(0)}: At this time of year, my grandpa used to take me hiking.
{GetName(1)}: Is that so?
{GetName(0)}: Yeah. Remembering him with his old cane always make me feel home. 
{GetName(1)}: Nice, I bet it was nice.
{GetName(0)}: Actually I was the one who made all the hiking, he'd walk for half a mile and then stop. 
{GetName(0)}: But the vistas were amazing.
->DONE
= LikeEarth1
{GetName(0)}: In any other scenery, I'd be gathering my crops by now.
{GetName(1)}: Were you a gardner back in the day?
{GetName(0)}: More like an enthusiast. I used to plant pumpkins in the mean time. They're spooky.
->DONE
= LikeEarth2
{GetName(0)}: So, how do you like my earrings?
{GetName(1)}: They're nice, I think.
{GetName(0)}: They were a gift from my mama. She used to tinker with jewelry, and she made those specially for me back in the day.
{GetName(0)}: It has diamonds engraved in the shape of a constellation. {She would always say it would guide me to home.|When I get lost, I look to it and search for the stars on the sky, so I know the way home.}
{GetName(1)}: Oh, that's actually nice.
->DONE
= DislikeEarth0
{GetName(0)}: I really miss a broom.
{GetName(1)}: ...What are you trying to tell me?
{GetName(0)}: I really miss a broom to sweep the floor, or having a floor to sweep. 
{GetName(0)}: You know, cleaning something, not having dirt in all of your clothes.
{GetName(1)}: Gosh, here I thought you were a witch!
->DONE
= DislikeEarth1
{GetName(0)}: You look like you want to ask something.
{GetName(1)}: Indeed, I do. I may have never noticed, but I saw you limping?
{GetName(0)}: You did, indeed. 
{GetName(0)}:When I was little, I fell from a cliff high enough to damage my knee. Since them I've been limping.
{GetName(1)}: Ouch
{GetName(0)}: Yeah, ouch. Not a fan of cliffs since then.
->DONE
= DislikeEarth2
{GetName(0)}: Mind if I share something with you?
{GetName(1)}: Sure, what is it?
{GetName(0)}: Don't make me go to the mine, please. When I was younger, I got stuck inside one for days.
{GetName(0)}: Since then, closed, confined spaces has been specially unsettling
{GetName(1)}: No need to worry, I'll remember that.
->DONE

= LikeFire0
{GetName(0)}: I'd do anything to light up a grill right now.
{GetName(1)}: What would you grill in it?
{GetName(0)}: Nothing in special, the greatest pleasure is lighting it up with two rocks and seeing the fire spread on the coal. It's so warming and comfy.
{GetName(1)}: So... Lighting only for the sake of lighting?
{GetName(0)}: Jackpot!
->DONE
= LikeFire1
{GetName(0)}: You know what is the best part of winter?
{GetName(1)}: What is it?
{GetName(0)}: The end of it. So spring may begin and the weather get warmer again
->DONE
= LikeFire2
{GetName(0)}: Are you feeling something different on the air?
{GetName(1)}: You mean the bittersweet smell on the air the whole night?
{GetName(0)}: Yes! Just got finished mixing some herbs and now I got a brand new incense. Did you like it?
{GetName(1)}: {I actually liked it a lot, I only wish it wasn't as strong as it is right now|Not exactly, is too much bitter and too much sweet. In the end is just a mess of differente smells begging for my attention.}
{GetName(0)}: I'll change the proportions and later I'll ask you again.
->DONE
= DislikeFire0
{GetName(0)}: The food was specially spicy tonight.
{GetName(1)}: That's unexpected, I don't believe to have done anything different.
{GetName(0)}: I wish I could make it less spicy. I mean, non-spicy at all.
{GetName(1)}: But then it would be almost tasteless.
{GetName(0)}: I disagree with that, your taste is already addicted to the pepper.
->DONE
= DislikeFire1
{GetName(0)}: You look like you want to ask something.
{GetName(1)}: I saw something on your arm, and it got me wondering what was it.
{GetName(0)}: It's a wound from when I was a kid. 
{GetName(0)}: Got burned with hot iron by accident and the mark never left.
{GetName(1)}: Oh, I'm sorry.
{GetName(0)}: That's alright, the mark makes me look cooler. Still would prefer not to get close to hot irons, though.
->DONE
= DislikeFire2
{GetName(0)}: Today is weirdly warm for an autumn night.
{GetName(1)}: You got that right.
{GetName(0)}: I wish I could make it cooler. Lift off this heavy sensation from the atmosphere, you know what I'm saying?
->DONE

= LikeAir0
{GetName(0)}: Windy nights like these always brings me memories from when I was a kid.
{GetName(1)}: Yeah, how so?
{GetName(0)}: How I used to fly kites.
{GetName(1)}: You used to?
{GetName(0)}: Yeah, I used to fly this big, bird-shaped, yellow kite. When the wind was right, it was the prettiest thing in the sky.
->DONE
= LikeAir1
{GetName(0)}: You like jazz?
{GetName(1)}: Beg your pardon?
{GetName(0)}: Jazz. Chet Bacon. Chicken Corea. John Colt-Raine. You know, jazz?
{GetName(1)}: Sorry, not a clue. I'm actually pretty clueless about jazz.
{GetName(0)}: Oh, that fine...
->DONE
= LikeAir2
{GetName(0)}: Look, a goose!
{GetName(1)}: Where?
{GetName(0)}: Up there in the sky! And look, a hound!
{GetName(1)}: Dude, are you aware that there are only clouds up there?
{GetName(0)}: Don't be such a buzzkill.
->DONE
= DislikeAir0
{GetName(0)}: What is your worst fear?
{GetName(1)}: Boogeyman? Mere trickery and boogeyman, I'd say. And your is?
{GetName(0)}: Heights. Being high. 
{GetName(0)}: Looking down and realizing I'm actually a couple of miles high. Gives me chills, dude.
->DONE
= DislikeAir1
{GetName(0)}: Another day I saw a kite.
{GetName(1)}: Kite, like a kite that children fly?
{GetName(0)}: Exactly.
{GetName(1)}: And what's wrong with it?
{GetName(0)}: I. 
{GetName(0)}: Hate. 
{GetName(0)}: Kites. 
{GetName(0)}: Never got how to fly one, nor what is the fun of it. It's so pointless and uninteresting.
->DONE
= DislikeAir2
{GetName(0)}: Can I share something with you that makes me really unconfortable?
{GetName(1)}: Sure, what is the matter?
{GetName(0)}: If a tornado hit us during the night, please hold me.
{GetName(1)}: I'm sorry, what?
{GetName(0)}: Tornados. They used to hit my hometown every now and then.
{GetName(0)}: I remember my neighbor, a chicken, flying towards the sky because of it. Scares the heck out of me.
{GetName(1)}: Don't worry, I'll tie you to a tree if a tornado hits us.
->DONE

= ProficienceWater0
{GetName(0)}: You see, these fish aren't as well prepared as they could be. I'm not complaining, but they could be something more tasteful.
{GetName(1)}: How do you know?
{GetName(0)}: Used to be a fisherman. Worked as a fisherman for years. There isn't a single way to cook fish that I don't know.
->DONE
= ProficienceWater1
{GetName(0)}: Oh boy, if we were back on my old town, I could serve you all the finest brew.
{GetName(1)}: What were you, some kind of barman?
{GetName(0)}: Precisely. I know better than anyone how some good ale is always welcome in company of good lads and good food.
->DONE
= ProficienceWater2
{GetName(0)}: Could we sing some sea shanties?
{GetName(1)}: I don't think we know any.
{GetName(0)}: Oh, don't worry, we have all night. I could teach you all some of the best ones for us to sing all night through.
->DONE
= ProficienceEarth0
{GetName(0)}: Being here outside brings me memories of new mown hay back at home. 
{GetName(0)}: Sittin' at the porch, smoking tobacco on my pipe, watching the crops, listening at the crickets at night. 
{GetName(0)}: Dayum, those were some good days.
{GetName(1)}: Are you sad it's over?
{GetName(0)}: Me? Not at all! I'm not sad because it's over, for I'm glad it happened and now I get to share my stories with some good folk!
->DONE
= ProficienceEarth1
{GetName(0)}: Back at the mines, we couldn't see the sky so clear like this. 
{GetName(0)}: Seeing something this starred and beautiful is breathtaking.
{GetName(1)}: I bet the diamonds at the mine were prettier.
{GetName(0)}: Nothing I've seen in any mine glittered as the stars at the night sky.
->DONE
= ProficienceEarth2
{GetName(0)}: Nights like this used to be the best ones to travel. So starred and bright, the path would always be clear almost entirely by the full moon.
{GetName(1)}: Weren't you afraid of the dark?
{GetName(0)}: I have nothing to fear under the full moon and a lit torch.
{GetName(1)}: That must be a really interesting life. You must be full of fascinating stories.
{GetName(0)}: Oh you can bet on it.
->DONE
= ProficienceFire0
{GetName(0)}: Guess who made the glass bottle you're holding right now.
{GetName(1)}: I'm clueless. Who did?
{GetName(0)}: I did.
{GetName(1)}: You're joking, right?
{GetName(0)}: I wish. I remember every bottle and cup I've blown, and this one was truly something. 
{GetName(0)}: I remember getting a pretty nasty burn on the upper lip with this one.
->DONE
= ProficienceFire1
{GetName(0)}: Whenever I close my eyes, I still listen to the whistle blowing.
{GetName(1)}: Whistle?
{GetName(0)}: Of the train I used to ride. Gigantic, powerful, masterfully crafted. 
{GetName(0)}: But it was hot. Heavens forgive me, but it was hot as hell.
->DONE
= ProficienceFire2
{GetName(0)}: A night like this used to make me feel inspired to craft horseshoes.
{GetName(1)}: Horsehoes?
{GetName(0)}: Actually, any kind of metalwork people payed me to do. 
{GetName(0)}: But mostly it was horsehoes. Horseshoes all day and night. People used to call me a master craftsman, but I don't quite buy it.
->DONE
= ProficienceAir0
{GetName(0)}: Tell me, you guys: do you dance?
{GetName(1)}: I used to dance at fairs, but I'm not that good of a dancer.
{GetName(0)}: There is no such thing as a bad dancer, you only need to feel the wind guide your limbs at the rhythm. Come on, dance with me.
{GetName(1)}: I pass.
{GetName(0)}: Hah! Passing such an opportunity as dancing with a professional dancer like me. You must be out of your mind!
->DONE
= ProficienceAir1
{GetName(0)}: A fine night like this really makes you wish you had your trusty guitar with you.
{GetName(1)}: Trusty guitar? What are you, a Bard?
{GetName(0)}: I'm not just a bard, I'm the - - Well, I used to be the best bard around. 
{GetName(0)}: Such a shame my career was shortlived, but the world shall hear my voice for many more years!
->DONE
= ProficienceAir2
{GetName(0)}: Such a fine night with a fine wind as this would be great for me to conduct tests!
{GetName(1)}: Tests such as...?
{GetName(0)}: Tests to see how could I glide using mechanical wings!
{GetName(1)}: Like a flying bird naturally do?
{GetName(0)}: Yes, but imagine all of us being able to fly just like a parakeet! I used to work on that, but my progress has been halted for a while.
{GetName(1)}: I'm sure you'll get back to work on your project soon enough.
->DONE

= BarkFood0
{GetName(0)}: Don't sweat it, I'll be back with a tasty dinner soon enough!
->DONE
= BarkFood1
{GetName(0)}: I'll be back until night with food, don't worry.
->DONE
= BarkFood2
{GetName(0)}: Do any of you don't eat meat? Just checking.
->DONE

= BarkDebrie0
{GetName(0)}: Clean-up is here, never fear!
->DONE
= BarkDebrie1
{GetName(0)}: Don't mind the mess, I'll be over soon enough with this.
->DONE
= BarkDebrie2
{GetName(0)}: Where do I dispose of all of this?
->DONE


= BarkWater0
{GetName(0)}: I'm listening to the sea waves crashing already!
->DONE
= BarkWater1
{GetName(0)}: Are seashells still on fashion? I hope they so!
->DONE
= BarkWater2
{GetName(0)}: Hope I'm lucky enough to find a seashell that sounds like the sea.
->DONE

= BarkAir0
{GetName(0)}: Do any of you have seen a dodo yet? I'd love to see one someday.
->DONE
= BarkAir1
{GetName(0)}: If I ask nice enough, would a peacock lend me some of its feathers?
->DONE
= BarkAir2
{GetName(0)}: Do any of you want to join me? I'll let you ask the bird for feathers!.
->DONE


= BarkFire0
{GetName(0)}: Wild flowers do make the best incenses, I'll show you.
->DONE
= BarkFire1
{GetName(0)}: Tonight I'll light something different, I hope it does smells nice.
->DONE
= BarkFire2
{GetName(0)}: You guys are sure you don't mind me lighting my incenses?
->DONE

= BarkEarth0
{GetName(0)}: Heigh-ho, heigh-ho, from home to work we go!
->DONE
= BarkEarth1
{GetName(0)}: I've already seen topaz, ruby, opala, lapis-lazuli, emerald and amethyst on these mines.
->DONE
= BarkEarth2
{GetName(0)}: Sometimes I wish I had built a tunnel from here already.
->DONE


= BarkWood0
{GetName(0)}: How many planks one need to make a canoe?
->DONE
= BarkWood1
{GetName(0)}: Someday, I'll take one of you so we can chop a tree and make a boat.
->DONE
= BarkWood2
{GetName(0)}: Okay, beside the campfire, do you guys want more wood?
->DONE

= BarkStone0
{GetName(0)}: Another day I saw a pile of tiny rocks, they were the cutest thing.
->DONE
= BarkStone1
{GetName(0)}: I've heard the best houses are built on stones, I hope the best homes do.
->DONE
= BarkStone2
{GetName(0)}: I'll look to bring home a fossile tonight.
->DONE

= Strike0
{GetName(0)}: Today was a bad day, but tomorrow will be better. I'm betting on it.
->DONE
= Strike1
{GetName(1)}: The last two days were pretty awful. I hope it changes soon.
->DONE
= Strike2
{GetName(2)}: I'm starting to feel that it didn't matter to leave my old group. Anywhere I go is the same thing.
->DONE

= StrikeBark0
{GetName(0)}: Leaving takes only two steps: a dose of courage and a couple of steps.
->DONE
= StrikeBark1
{GetName(0)}: I'm starting to ponder if it's worth to waste time here.
->DONE
= StrikeBark2
{GetName(0)}: Tomorrow I'll leave. I'm only waiting for when the time is right.
->DONE

= StrikeLoss0
{GetName(0)}: I guess it only takes time for things to get better.
->DONE
= StrikeLoss1
{GetName(0)}: Okay, today was pretty alright. Let's do it tomorrow again!
->DONE
= StrikeLoss2
{GetName(0)}: There's no place like home for some self-healing.
->DONE

= LosingMember0
{GetName(0)}: I can't do this anymore. I know you tried your best, but I can't just be here. It's like nothing has changed from the last camp I've been.
{GetName(1)}: I'm sorry we couldn't make it better for you.
{GetName(0)}: Null sweat, {GetName(1)}, it's nobody's fault. I just didn't manage to fit in, that's all.
{GetName(1)}: Farewell, {GetName(0)}. Farewell.
{GetName(0)}: See you next time.
->DONE
= LosingMember1
{GetName(0)}: My time has come to leave, my friends.
{GetName(1)}: Are you sure of venturing out like this?
{GetName(0)}: Yes, I don't belong here. I don't feel like home. But I hope to see you all soon around.
{GetName(1)}: Bon voyage, {GetName(0)}.
->DONE
= LosingMember2
{GetName(1)}: Are you leaving?
{GetName(0)}: Yeah, {GetName(1)}, I'm leaving. I'm sorry for not telling anyone about it before, but I can't stand being in this camp anymore.
{GetName(1)}: For how long have you been thinking about it?
{GetName(0)}: A while now. I can't stay at a place where I don't feel like home.
{GetName(1)}: I see. That's why we all came here, right?
{GetName(0)}: Yeah. Farewell, {GetName(1)}.
{GetName(1)}: Farewell, {GetName(0)}.
->DONE

= LikingItemP0
{GetName(0)}: That's a nice {GetItem(0)}. I'm glad somebody built one.
->DONE

= LikingItemP1
{GetName(0)}: I love that now I've got a {GetItem(0)} in my tent!
->DONE

= LikingItemP2
{GetName(0)}: Finally got a {GetItem(0)}. I'm starting to feel at home!
->DONE

= DislikingItemP0
{GetName(0)}: {GetItem(0)} gives me goosebumps.
->DONE

= DislikingItemP1
{GetName(0)}: I don't get {GetItem(0)}. Care to explain why do you like it?
->DONE

= DislikingItemP2
{GetName(0)}: I'm not particularly fond of {GetItem(0)}. But at least somebody around here is.
->DONE

= NeutralItemP0
{GetName(1)}: So, what do you think of {GetItem(0)}?
{GetName(0)}: I'm not in love by it, but I don't dislike it either.
{GetName(1)}: So... Neutral?
{GetName(0)}: As neutral as I can be.
->DONE

= NeutralItemP1
{GetName(0)}: Have you seen {GetItem(0)}?
{GetName(1)}: Yup. Did you like it?
{GetName(0)}: Don't have any strong feelings by it. I thought you'd like to see it, that's all.
->DONE

= NeutralItemP2
{GetName(1)}: How are you?
{GetName(0)}: Puzzled by {GetItem(0)}.
{GetName(1)}: Why, didn't you like it?
{GetName(0)}: That's not it. I didn't hate it, but I don't see the point of it.
->DONE

=== function GetName(p) ===

~ return "P{p}"

=== function GetSurname(p) ===

~ return "S{p}"

=== function GetLike(p) ===

~ return "Like(p)"

=== function GetDislike(p) ===
~ return "Dislike(p)"

=== function GetProficiency(p) ===
~ return "Prof(p)"

=== function GetItem(p) ===
~ return "Item(p)"