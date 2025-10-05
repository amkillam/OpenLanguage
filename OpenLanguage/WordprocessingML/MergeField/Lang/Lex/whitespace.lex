"//".*                                                                            { /* skip single-line comment */ }
[\r][\n]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
[\n]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
[\r]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Line separator
[\u2028]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Paragraph separator
[\u2029]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Line tabulation/Vertical tab (VT)
[\u000B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Form feed
[\u000C]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
[ \t]                                                                             { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE; }
// Ogham space mark
[\u1680]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
[\u2000-\u200A]                                                                   { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Medium mathematical space
[\u202F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Narrow no-break space
[\u205F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Ideographic space
[\u3000]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Zero width space
[\u200B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Non-breaking space
[\u00A0]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE; }
// Zero width no-break space
[\uFEFF]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }

// Unicode control characters
// The \u20[01-0a] range is often erroneously emitted to the lexer as two separate \u20 and \u[01-0A] characters, as \u20 is detected as a space.
// As such, we include all control characters in this range here, and retain them as whitespace.
// Start of Heading (SOH)
[\u0001]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Start of Text (STX)
[\u0002]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// End of Text (ETX)
[\u0003]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// End of Transmission (EOT)
[\u0004]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Enquiry (ENQ)
[\u0005]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Acknowledge (ACK)
[\u0006]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Bell (BEL)
[\u0007]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Backspace (BS)
[\u0008]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Shift in
[\u000E]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Shift out
[\u000F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Data Link Escape (DLE)
[\u0010]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Device Control 1 (DC1)
[\u0011]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Device Control 2 (DC2)
[\u0012]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Device Control 3 (DC3)
[\u0013]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Device Control 4 (DC4)
[\u0014]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Negative Acknowledge (NAK)
[\u0015]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Synchronous Idle (SYN)
[\u0016]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// End of Transmission Block (ETB)
[\u0017]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Cancel (CAN)
[\u0018]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// End of Medium (EM)
[\u0019]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Substitute (SUB)
[\u001A]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Escape (ESC)
[\u001B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// File Separator (FS)
[\u001C]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Group Separator (GS)
[\u001D]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Record Separator (RS)
[\u001E]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Unit Separator (US)
[\u001F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Delete (DEL)
[\u007F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
