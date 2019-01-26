CONST WATER = 0
CONST EARTH = 1
CONST FIRE = 2
CONST AIR = 3

EXTERNAL GetName(p)
EXTERNAL GetSurname(p)
EXTERNAL GetLike(p)
EXTERNAL GetDislike(p)
EXTERNAL GetProficiency(p)

= Leaving_camp

{GetName(1)} I think it's time for me to say goodbye to you all.
{GetName(2)} Are you sure of this?
{GetName(1)} Sadly, I don't feel at home being here. Nothing personal, but I feel the need to look for somewhere where I can feel at home.
{GetName(2)} I'm sorry to hear that, {GetName(1)}.
{GetName(3)} I hope you look what you're looking for..
{GetName(1)} If we happen to meet again, I hope to be able to receive you guys with the same hospitality you showed me.
{GetName(2)} Farewell!
{GetName(3)} Farewell!
...
{GetName(2)} God damn it, he was the most hardworking of all of us.


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