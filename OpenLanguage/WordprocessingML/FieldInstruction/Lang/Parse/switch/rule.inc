switch_a:
    whitespace switch_a { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_a whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_A          { $$ = new BoolFlagNode($1); }
  ;


switch_ac:
    whitespace switch_ac { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_ac whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_AC          { $$ = new FlagNode($1); }
  ;


switch_ai:
    whitespace switch_ai { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_ai whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_AI          { $$ = new FlagNode($1); }
  ;


switch_al:
    whitespace switch_al { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_al whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_AL          { $$ = new FlagNode($1); }
  ;


switch_ar:
    whitespace switch_ar { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_ar whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_AR          { $$ = new FlagNode($1); }
  ;


switch_b:
    whitespace switch_b { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_b whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_B          { $$ = new BoolFlagNode($1); }
  ;


switch_ba:
    whitespace switch_ba { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_ba whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_BA          { $$ = new FlagNode($1); }
  ;


switch_bc:
    whitespace switch_bc { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_bc whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_BC          { $$ = new FlagNode($1); }
  ;


switch_bo:
    whitespace switch_bo { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_bo whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_BO          { $$ = new BoolFlagNode($1); }
  ;


switch_c:
    whitespace switch_c { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_c whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_C          { $$ = new FlagNode($1); }
  ;

bool_switch_c:
    whitespace bool_switch_c { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | bool_switch_c whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_C          { $$ = new BoolFlagNode($1); }
  ;


switch_co:
    whitespace switch_co { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_co whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_CO          { $$ = new FlagNode($1); }
  ;


switch_d:
    whitespace switch_d { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_d whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_D          { $$ = new BoolFlagNode($1); }
  ;


switch_di:
    whitespace switch_di { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_di whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_DI          { $$ = new FlagNode($1); }
  ;


switch_do:
    whitespace switch_do { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_do whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_DO          { $$ = new FlagNode($1); }
  ;


bool_switch_e:
    whitespace bool_switch_e { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | bool_switch_e whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_E          { $$ = new BoolFlagNode($1); }
  ;

switch_e:
    whitespace switch_e { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_e whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_E          { $$ = new FlagNode($1); }
  ;


switch_f:
    whitespace switch_f { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_f whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_F          { $$ = new BoolFlagNode($1); }
  ;


switch_fc:
    whitespace switch_fc { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_fc whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_FC          { $$ = new FlagNode($1); }
  ;


switch_fo:
    whitespace switch_fo { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_fo whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_FO          { $$ = new FlagNode($1); }
  ;


switch_g:
    whitespace switch_g { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_g whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_G          { $$ = new BoolFlagNode($1); }
  ;


switch_h:
    whitespace switch_h { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_h whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_H          { $$ = new BoolFlagNode($1); }
  ;


switch_hs:
    whitespace switch_hs { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_hs whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_HS          { $$ = new FlagNode($1); }
  ;


switch_i:
    whitespace switch_i { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_i whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_I          { $$ = new BoolFlagNode($1); }
  ;


switch_in:
    whitespace switch_in { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_in whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_IN          { $$ = new BoolFlagNode($1); }
  ;


switch_j:
    whitespace switch_j { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_j whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_J          { $$ = new BoolFlagNode($1); }
  ;


switch_k:
    whitespace switch_k { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_k whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_K          { $$ = new BoolFlagNode($1); }
  ;


switch_l:
    whitespace switch_l { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_l whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_L          { $$ = new BoolFlagNode($1); }
  ;


switch_lc:
    whitespace switch_lc { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_lc whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_LC          { $$ = new FlagNode($1); }
  ;


switch_le:
    whitespace switch_le { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_le whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_LE          { $$ = new BoolFlagNode($1); }
  ;


switch_li:
    whitespace switch_li { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_li whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_LI          { $$ = new BoolFlagNode($1); }
  ;


switch_m:
    whitespace switch_m { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_m whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_M          { $$ = new BoolFlagNode($1); }
  ;

switch_n_flag:
    whitespace switch_n_flag { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_n_flag whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_N          { $$ = new FlagNode($1); }
  ;

switch_n:
    whitespace switch_n { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_n whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_N          { $$ = new BoolFlagNode($1); }
  ;


switch_o:
    whitespace switch_o { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_o whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_O          { $$ = new BoolFlagNode($1); }
  ;


switch_p:
    whitespace switch_p { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_p whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_P          { $$ = new BoolFlagNode($1); }
  ;


switch_pr:
    whitespace switch_pr { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_pr whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_PR          { $$ = new FlagNode($1); }
  ;


switch_r:
    whitespace switch_r { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_r whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_R          { $$ = new BoolFlagNode($1); }
  ;


switch_rc:
    whitespace switch_rc { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_rc whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_RC          { $$ = new FlagNode($1); }
  ;


switch_ri:
    whitespace switch_ri { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_ri whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_RI          { $$ = new BoolFlagNode($1); }
  ;


switch_s:
    whitespace switch_s { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_s whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_S          { $$ = new FlagNode($1); }
  ;

bool_switch_s:
    whitespace bool_switch_s { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | bool_switch_s whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_S          { $$ = new BoolFlagNode($1); }
  ;


switch_su:
    whitespace switch_su { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_su whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_SU          { $$ = new FlagNode($1); }
  ;


switch_t:
    whitespace switch_t { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_t whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_T          { $$ = new BoolFlagNode($1); }
  ;


switch_to:
    whitespace switch_to { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_to whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_TO          { $$ = new BoolFlagNode($1); }
  ;


switch_u:
    whitespace switch_u { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_u whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_U          { $$ = new BoolFlagNode($1); }
  ;


switch_up:
    whitespace switch_up { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_up whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_UP          { $$ = new FlagNode($1); }
  ;


switch_v:
    whitespace switch_v { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_v whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_V          { $$ = new BoolFlagNode($1); }
  ;


switch_vc:
    whitespace switch_vc { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_vc whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_VC          { $$ = new FlagNode($1); }
  ;


switch_vs:
    whitespace switch_vs { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_vs whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_VS          { $$ = new FlagNode($1); }
  ;


switch_w:
    whitespace switch_w { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_w whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_W          { $$ = new BoolFlagNode($1); }
  ;


switch_x:
    whitespace switch_x { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_x whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_X          { $$ = new FlagNode($1); }
  ;


switch_y:
    whitespace switch_y { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_y whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_Y          { $$ = new BoolFlagNode($1); }
  ;


switch_z:
    whitespace switch_z { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_z whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_Z          { $$ = new BoolFlagNode($1); }
  ;

switch_asterisk:
    whitespace switch_asterisk { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_asterisk whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_ASTERISK          { $$ = new FlagNode($1); }
  ;

switch_pound:
    whitespace switch_pound { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_pound whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_POUND          { $$ = new FlagNode($1); }
  ;

switch_at:
    whitespace switch_at { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_at whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_AT          { $$ = new FlagNode($1); }
  ;

switch_exclamation:
    whitespace switch_exclamation { $$ = $2; $$.LeadingWhitespace.Insert(0, $1); }
  | switch_exclamation whitespace { $$ = $1; $$.TrailingWhitespace.Add($2); }
  | T_SWITCH_EXCLAMATION          { $$ = new BoolFlagNode($1); }
  ;
