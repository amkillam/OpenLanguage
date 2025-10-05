"//".*                                                                            { /* skip single-line comment */ }
[\r][\n]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
[\n]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
[\r]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
// Line separator
[\u2028]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
// Paragraph separator
[\u2029]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
// Line tabulation/Vertical tab (VT)
[\u000B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
// Form feed
[\u000C]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_NEWLINE;  }
[ \t]                                                                             { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }
// Ogham space mark
[\u1680]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
[\u2000-\u200A]                                                                   { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Medium mathematical space
[\u202F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Narrow no-break space
[\u205F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Ideographic space
[\u3000]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Zero width space
[\u200B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Non-breaking space
[\u00A0]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION; }
// Zero width no-break space
[\uFEFF]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }

// Unicode control characters
// The \u20[01-0a] range is often erroneously emitted to the lexer as two separate \u20 and \u[01-0A] characters, as \u20 is detected as a space.
// As such, we include all control characters in this range here, and retain them as whitespace.
// Start of Heading (SOH)
[\u0001]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Start of Text (STX)
[\u0002]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// End of Text (ETX)
[\u0003]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// End of Transmission (EOT)
[\u0004]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Enquiry (ENQ)
[\u0005]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Acknowledge (ACK)
[\u0006]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Bell (BEL)
[\u0007]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Backspace (BS)
[\u0008]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Shift in
[\u000E]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Shift out
[\u000F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Data Link Escape (DLE)
[\u0010]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Device Control 1 (DC1)
[\u0011]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Device Control 2 (DC2)
[\u0012]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Device Control 3 (DC3)
[\u0013]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Device Control 4 (DC4)
[\u0014]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Negative Acknowledge (NAK)
[\u0015]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Synchronous Idle (SYN)
[\u0016]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// End of Transmission Block (ETB)
[\u0017]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Cancel (CAN)
[\u0018]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// End of Medium (EM)
[\u0019]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Substitute (SUB)
[\u001A]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Escape (ESC)
[\u001B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// File Separator (FS)
[\u001C]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Group Separator (GS)
[\u001D]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Record Separator (RS)
[\u001E]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Unit Separator (US)
[\u001F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
// Delete (DEL)
[\u007F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_INTERSECTION;  }
