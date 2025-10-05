"//".*                                                                            { /* skip single-line comment */ }
[\r][\n]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
[\n]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
[\r]                                                                              { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Line separator
[\u2028]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Paragraph separator
[\u2029]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Line tabulation/Vertical tab (VT)
[\x0B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Form feed
[\x0C]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
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
[\xA0]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE; }
// Zero width no-break space
[\uFEFF]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }

// Unicode control characters
// The \u20[01-0a] range is often erroneously emitted to the lexer as two separate \u20 and \u[01-0A] characters, as \u20 is detected as a space.
// As such, we include all control characters in this range here, and retain them as whitespace.
// Start of Heading (SOH)
[\x01]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Start of Text (STX)
[\x02]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// End of Text (ETX)
[\x03]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// End of Transmission (EOT)
[\x04]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Enquiry (ENQ)
[\x05]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Acknowledge (ACK)
[\x06]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Bell (BEL)
[\x07]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Backspace (BS)
[\x08]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Shift in
[\x0E]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Shift out
[\x0F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Data Link Escape (DLE)
[\x10]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Device Control 1 (DC1)
[\x11]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Device Control 2 (DC2)
[\x12]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Device Control 3 (DC3)
[\x13]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Device Control 4 (DC4)
[\x14]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Negative Acknowledge (NAK)
[\x15]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Synchronous Idle (SYN)
[\x16]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// End of Transmission Block (ETB)
[\x17]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Cancel (CAN)
[\x18]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// End of Medium (EM)
[\x19]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Substitute (SUB)
[\x1A]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Escape (ESC)
[\x1B]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// File Separator (FS)
[\x1C]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Group Separator (GS)
[\x1D]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Record Separator (RS)
[\x1E]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Unit Separator (US)
[\x1F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
// Delete (DEL)
[\x7F]                                                                          { yylval.stringVal = yytext; return (int)Tokens.T_WHITESPACE;  }
